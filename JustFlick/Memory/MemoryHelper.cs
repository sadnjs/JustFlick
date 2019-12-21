using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 봉순봇
{
    class MemoryHelper
    {
        static int procHandle = 0;
        static uint mbiSize = 0;
        static Process proc;
        public static IntPtr windowHandle;
        public static MEMORY_BASIC_INFORMATION64[] mbis;
        public static bool CompressMbis = false;
        public static IntPtr GetWindowHandle()
        {
            return proc.MainWindowHandle;
        }

        public static long BaseAddress
        {
            get
            {
                return proc.MainModule.BaseAddress.ToInt64();
            }
        }

        public static void OpenProcess(string procName)
        {
            proc = Process.GetProcessesByName(procName)[0];
            procHandle = OpenProcess(0x001F0FFF, false, proc.Id);
            windowHandle = proc.MainWindowHandle;
            mbiSize = (uint)Marshal.SizeOf<MEMORY_BASIC_INFORMATION64>();
        }

        public static void SetRgSize(int size)
        {
            minRgSize = size;
            maxRgSize = size;
            CompressMbis = false;
        }

        public static bool HasExited()
        {
            return proc.MainWindowHandle == IntPtr.Zero || proc.ExitCode == 0;
        }

        public static int UpdateMemReg()
        {
            MEMORY_BASIC_INFORMATION64 mbi;
            Int64 current_address = 0x7ffe0000;
            List<MEMORY_BASIC_INFORMATION64> addresses = new List<MEMORY_BASIC_INFORMATION64>();
            MEMORY_BASIC_INFORMATION64 old = new MEMORY_BASIC_INFORMATION64();
            while (true)
            {
                int MemDump = VirtualQueryEx(procHandle, current_address, out mbi, mbiSize);
                if (MemDump == 0)
                    break;
                if ((mbi.State & 0x1000) != 0 && (mbi.Protect & 0x100) == 0)
                {
                    if (old.BaseAddress + old.RegionSize == mbi.BaseAddress && CompressMbis)
                        old.RegionSize += mbi.RegionSize;
                    else
                        addresses.Add(mbi);
                    old = mbi;
                }
                current_address = (Int64)(mbi.BaseAddress + mbi.RegionSize);
            }
            mbis = addresses.ToArray<MEMORY_BASIC_INFORMATION64>();
            return mbis.Length;
        }
        static int bufSize = 4096;

        public static Int64[] FindPatternsExReg(byte[] pattern, string mask)
        {
            UpdateMemReg();
            List<Int64> result = new List<Int64>();
            for (int i = 0; i < mbis.Length; i++)
            {
                MEMORY_BASIC_INFORMATION64 info = mbis[i];
                result.AddRange(FindPatternEx((Int64)info.BaseAddress, (Int64)(info.RegionSize + info.BaseAddress), pattern, mask, info));
            }

            for (int i = 0; i < mbis.Length; i++)
            {
                MEMORY_BASIC_INFORMATION64 info = mbis[i];
                foreach (Int64 test in result)
                {
                    if (test > (long)info.BaseAddress && test - (long)info.BaseAddress < (long)info.RegionSize)
                    {
                    }

                }

            }

            return result.ToArray<Int64>();
        }

        public static Int64 FindPatternExReg(byte[] pattern, string mask)
        {
            UpdateMemReg();
            Array.Reverse(mbis);
            List<Int64> result = new List<Int64>();
            for (int i = 0; i < mbis.Length; i++)
            {
                MEMORY_BASIC_INFORMATION64 info = mbis[i];
                var arr = FindPatternEx((Int64)info.BaseAddress, (Int64)(info.RegionSize + info.BaseAddress), pattern, mask, info);
                if (arr.Length > 0)
                {
                    for (int x = 0; x < mbis.Length; x++)
                    {
                        MEMORY_BASIC_INFORMATION64 nfo = mbis[x];
                        foreach (Int64 test in arr)
                        {
                            if (test > (long)nfo.BaseAddress && test - (long)nfo.BaseAddress < (long)nfo.RegionSize)
                            {

                            }
                        }
                    }
                    return arr[0];
                }
            }
            return 0;
        }
        public static int maxRgSize = 0, minRgSize = 0;
        public static Int64[] FindPatternEx(Int64 start, Int64 end, byte[] pattern, string mask, MEMORY_BASIC_INFORMATION64 mbi)
        {
            Int64 current_chunk = start;
            int bytesRead = 0;
            List<Int64> found = new List<Int64>();
            if ((end - current_chunk > maxRgSize && maxRgSize != 0) || (end - current_chunk < minRgSize && minRgSize != 0))
                return found.ToArray<Int64>();
            while (current_chunk < end)
            {
                bufSize = (int)(end - start);
                byte[] buffer = new byte[bufSize];
                if (!ReadProcessMemory(procHandle, current_chunk, buffer, bufSize, out bytesRead))
                {
                    current_chunk += bufSize;
                    continue;
                }
                Int64 internal_address = FindPattern(buffer, pattern, mask);
                if (internal_address != -1)
                {
                    found.Add(current_chunk + internal_address);
                }
                current_chunk += bufSize;
            }
            return found.ToArray<Int64>();
        }

        public static float ReadFloat(long address)
        {
            byte[] input = Read(address, 4);
            return BitConverter.ToSingle(input, 0);
        }

        public static Int64 FindPattern(byte[] buffer, byte[] pattern, string mask)
        {
            int pattern_len = mask.Length;
            for (int i = 0; i < buffer.Length - pattern_len; i++)
            {
                bool found = true;
                for (int j = 0; j < pattern_len; j++)
                {
                    if (mask[j] != '?' && pattern[j] != buffer[i + j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    return i;
            }
            return -1;
        }

        public static Int64[] FindPatterns(byte[] buffer, byte[] pattern, string mask)
        {
            List<Int64> ret = new List<long>();
            int pattern_len = mask.Length;
            for (int i = 0; i < buffer.Length - pattern_len; i++)
            {
                bool found = true;
                for (int j = 0; j < pattern_len; j++)
                {
                    if (mask[j] != '?' && pattern[j] != buffer[i + j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                    ret.Add(i);
            }
            return ret.ToArray();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION64
        {
            public ulong BaseAddress;
            public ulong AllocationBase;
            public int AllocationProtect;
            public int __alignment1;
            public ulong RegionSize;
            public int State;
            public int Protect;
            public int Type;
            public int __alignment2;
        }

        public static byte[] Read(Int64 address, int length)
        {
            byte[] buf = new byte[length];
            if (!ReadProcessMemory(procHandle, address, buf, length, out int trash))
            {
                return null;
            }
            return buf;
        }

        public static T ReadMemory<T>(Int64 Address, int size, bool unicode = false)
        {
            byte[] readbyte;
            if (typeof(T).Equals(typeof(string)))
                if (unicode)
                    readbyte = new byte[size * 2 + 1];
                else
                    readbyte = new byte[size];
            else if (typeof(T) == typeof(byte[]))
                readbyte = new byte[size];
            else
                readbyte = new byte[Marshal.SizeOf(typeof(T))];

            if (!ReadProcessMemory(procHandle, Address, readbyte, size, out int temp))
                return default(T);
            else if (typeof(T) == typeof(byte[]))
                return (T)(object)readbyte;
            else if (typeof(T) == typeof(string))
                if (unicode)
                    return (T)(object)Encoding.Unicode.GetString(readbyte);
                else
                    return (T)(object)(Encoding.ASCII.GetString(readbyte));
            else
            {
                GCHandle gchandle = GCHandle.Alloc(readbyte, GCHandleType.Pinned);
                T t = (T)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(T));
                gchandle.Free();
                return t;
            }
        }

        public static Vector3 ReadVector3(long address)
        {
            byte[] buffer = new byte[3 * 4];

            ReadProcessMemory(procHandle, address, buffer, buffer.Length, out int bytesRead);

            Vector3 vec = new Vector3();
            vec.x = BitConverter.ToSingle(buffer, (0 * 4));
            vec.y = BitConverter.ToSingle(buffer, (1 * 4));
            vec.z = BitConverter.ToSingle(buffer, (2 * 4));
            return vec;
        }

        public static Matrix ReadMatrix(long address)
        {
            byte[] buffer = new byte[16 * 4];

            ReadProcessMemory(procHandle, address, buffer, buffer.Length, out int bytesRead);

            Matrix mat = new Matrix();
            mat.m11 = BitConverter.ToSingle(buffer, (0 * 4));
            mat.m12 = BitConverter.ToSingle(buffer, (1 * 4));
            mat.m13 = BitConverter.ToSingle(buffer, (2 * 4));
            mat.m14 = BitConverter.ToSingle(buffer, (3 * 4));

            mat.m21 = BitConverter.ToSingle(buffer, (4 * 4));
            mat.m22 = BitConverter.ToSingle(buffer, (5 * 4));
            mat.m23 = BitConverter.ToSingle(buffer, (6 * 4));
            mat.m24 = BitConverter.ToSingle(buffer, (7 * 4));

            mat.m31 = BitConverter.ToSingle(buffer, (8 * 4));
            mat.m32 = BitConverter.ToSingle(buffer, (9 * 4));
            mat.m33 = BitConverter.ToSingle(buffer, (10 * 4));
            mat.m34 = BitConverter.ToSingle(buffer, (11 * 4));

            mat.m41 = BitConverter.ToSingle(buffer, (12 * 4));
            mat.m42 = BitConverter.ToSingle(buffer, (13 * 4));
            mat.m43 = BitConverter.ToSingle(buffer, (14 * 4));
            mat.m44 = BitConverter.ToSingle(buffer, (15 * 4));
            return mat;
        }

        [DllImport("kernel32.dll")]
        static extern int VirtualQueryEx(int hProcess, Int64 lpAddress, out MEMORY_BASIC_INFORMATION64 lpBuffer, uint dwLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int OpenProcess(int processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(int hProcess, Int64 lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
    }
}
