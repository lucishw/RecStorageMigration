using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    class KMSManager
    {
        [DllImport(@"MediaParser.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateCMediaParser();

        [DllImport(@"MediaParser.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeCMediaParser(IntPtr pObject);

        [DllImport(@"MediaParser.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init(IntPtr pObject, string pProxyAddr, string pDomain, string pUser, string pPass, string pWebAuthIP, short nWebAuthPort, short nTestMode);

        [DllImport(@"MediaParser.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LucisDecryptFile(IntPtr pObject, int ext, byte[] pSrc, int lngSrcLen, byte[] pDst, int[] lngDstLen);

        [DllImport(@"MediaParser.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LucisEncryptFile(IntPtr pObject, int ext, byte[] pSrc, int lngSrcLen, byte[] pDst, int[] lngDstLen, byte[] pKeyID);       

        IntPtr pKMS = CreateCMediaParser();
        LogManager _Log = new LogManager();

        public KMSManager()
        {
            _Log.CreateLogFile();
        }

        public int KMSInit(string KMSServerIP, string KMSDomain, string KMSServerID, string KMSServerPW, string KMSAuthIP, string KMSAuthPort)
        {
            try
            {
                int ret = Init(pKMS, KMSServerIP, KMSDomain, KMSServerID, KMSServerPW, KMSAuthIP, Convert.ToInt16(KMSAuthPort), 0);
                return ret;
            }
            catch (Exception ex)
            {
                _Log.LogMessage("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message);
                return 0;
            }
        }

        public int KMSDecryptFile(string SrcFile, string DstFile)
        {
            try
            {
                int[] lngDstLen = { 10 };
                int ret = 0;

                using (FileStream fsSource = new FileStream(SrcFile, FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    byte[] bytes2 = new byte[fsSource.Length * 2];

                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;

                    ret = LucisDecryptFile(pKMS, 1, bytes, numBytesToRead, bytes2, lngDstLen);
                    if (ret != 1)
                    {
                        DisposeCMediaParser(pKMS);
                        pKMS = IntPtr.Zero;
                        return ret;
                    }

                    // Write the byte array to the other FileStream.
                    using (FileStream fsNew = new FileStream(DstFile, FileMode.Create, FileAccess.Write))
                    {
                        fsNew.Write(bytes2, 0, (int)lngDstLen[0]);
                    }
                }

                return ret;
            }
            catch (Exception ex)
            {
                _Log.LogMessage("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message);
                return 0;
            }
        }

        public int KMSEncryptFile(string SrcFile, string DstFile, string Key)
        {
            try
            {
                int[] pDstLen = new int[1];
                int ret = 0;

                using (FileStream fsSrc = new FileStream(SrcFile, FileMode.Open, FileAccess.Read))
                {
                    byte[] pSrc = new byte[fsSrc.Length];
                    byte[] pDst = new byte[fsSrc.Length * 2];

                    fsSrc.Read(pSrc, 0, (int)fsSrc.Length);

                    ret = LucisEncryptFile(pKMS, 1, pSrc, (int)fsSrc.Length, pDst, pDstLen, Encoding.UTF8.GetBytes(Key));

                    if (ret == 1)
                    {
                        using (FileStream fsDst = new FileStream(DstFile, FileMode.Create, FileAccess.Write))
                        {
                            fsDst.Write(pDst, 0, (int)pDstLen[0]);
                        }
                    }
                }

                return ret;
            }
            catch (Exception ex)
            {
                _Log.LogMessage("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message);
                return 0;
            }
        }
    }
}
