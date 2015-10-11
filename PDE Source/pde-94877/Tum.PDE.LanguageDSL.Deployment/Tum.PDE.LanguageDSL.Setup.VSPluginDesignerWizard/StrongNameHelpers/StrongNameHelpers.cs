using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Runtime.Hosting
{
    /// <summary>
    /// Source: DSL Tools
    /// </summary>
    internal sealed class StrongNameHelpers
    {

        [System.Security.SecurityCritical]
        [System.ThreadStatic]
        private static Microsoft.Runtime.Hosting.IClrStrongName s_StrongName;
        [System.ThreadStatic]
        private static int ts_LastStrongNameHR;

        private static Microsoft.Runtime.Hosting.IClrStrongName StrongName
        {
            get
            {
                if (Microsoft.Runtime.Hosting.StrongNameHelpers.s_StrongName == null)
                    Microsoft.Runtime.Hosting.StrongNameHelpers.s_StrongName = (Microsoft.Runtime.Hosting.IClrStrongName)System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(new System.Guid("B79B0ACD-F5CD-409b-B5A5-A16244610B92"), new System.Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D"));
                return Microsoft.Runtime.Hosting.StrongNameHelpers.s_StrongName;
            }
        }

        private static Microsoft.Runtime.Hosting.IClrStrongNameUsingIntPtr StrongNameUsingIntPtr
        {
            get
            {
                return (Microsoft.Runtime.Hosting.IClrStrongNameUsingIntPtr)Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName;
            }
        }

        [System.Security.SecurityCritical]
        public static int StrongNameErrorInfo()
        {
            return Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR;
        }

        [System.Security.SecurityCritical]
        public static void StrongNameFreeBuffer(System.IntPtr pbMemory)
        {
            Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameFreeBuffer(pbMemory);
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameGetPublicKey(string pwzKeyContainer, byte[] bKeyBlob, int cbKeyBlob, out System.IntPtr ppbPublicKeyBlob, out int pcbPublicKeyBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameGetPublicKey(pwzKeyContainer, bKeyBlob, cbKeyBlob, out ppbPublicKeyBlob, out pcbPublicKeyBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                ppbPublicKeyBlob = System.IntPtr.Zero;
                pcbPublicKeyBlob = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameGetPublicKey(string pwzKeyContainer, System.IntPtr pbKeyBlob, int cbKeyBlob, out System.IntPtr ppbPublicKeyBlob, out int pcbPublicKeyBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameGetPublicKey(pwzKeyContainer, pbKeyBlob, cbKeyBlob, out ppbPublicKeyBlob, out pcbPublicKeyBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                ppbPublicKeyBlob = System.IntPtr.Zero;
                pcbPublicKeyBlob = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameKeyDelete(string pwzKeyContainer)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameKeyDelete(pwzKeyContainer);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameKeyGen(string pwzKeyContainer, int dwFlags, out System.IntPtr ppbKeyBlob, out int pcbKeyBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameKeyGen(pwzKeyContainer, dwFlags, out ppbKeyBlob, out pcbKeyBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                ppbKeyBlob = System.IntPtr.Zero;
                pcbKeyBlob = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameKeyInstall(string pwzKeyContainer, byte[] bKeyBlob, int cbKeyBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameKeyInstall(pwzKeyContainer, bKeyBlob, cbKeyBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameKeyInstall(string pwzKeyContainer, System.IntPtr pbKeyBlob, int cbKeyBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameKeyInstall(pwzKeyContainer, pbKeyBlob, cbKeyBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, System.IntPtr pbKeyBlob, int cbKeyBlob)
        {
            System.IntPtr intPtr = System.IntPtr.Zero;
            int i = 0;
            return Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, ref intPtr, out i);
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, byte[] bKeyBlob, int cbKeyBlob)
        {
            System.IntPtr intPtr = System.IntPtr.Zero;
            int i = 0;
            return Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, bKeyBlob, cbKeyBlob, ref intPtr, out i);
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, System.IntPtr pbKeyBlob, int cbKeyBlob, ref System.IntPtr ppbSignatureBlob, out int pcbSignatureBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, pbKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pcbSignatureBlob = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureGeneration(string pwzFilePath, string pwzKeyContainer, byte[] bKeyBlob, int cbKeyBlob, ref System.IntPtr ppbSignatureBlob, out int pcbSignatureBlob)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameSignatureGeneration(pwzFilePath, pwzKeyContainer, bKeyBlob, cbKeyBlob, ppbSignatureBlob, out pcbSignatureBlob);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pcbSignatureBlob = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureSize(byte[] bPublicKeyBlob, int cbPublicKeyBlob, out int pcbSize)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameSignatureSize(bPublicKeyBlob, cbPublicKeyBlob, out pcbSize);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pcbSize = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureSize(System.IntPtr pbPublicKeyBlob, int cbPublicKeyBlob, out int pcbSize)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameSignatureSize(pbPublicKeyBlob, cbPublicKeyBlob, out pcbSize);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pcbSize = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureVerification(string pwzFilePath, int dwInFlags, out int pdwOutFlags)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameSignatureVerification(pwzFilePath, dwInFlags, out pdwOutFlags);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pdwOutFlags = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameSignatureVerificationEx(string pwzFilePath, bool fForceVerification, out bool pfWasVerified)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameSignatureVerificationEx(pwzFilePath, fForceVerification, out pfWasVerified);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                pfWasVerified = false;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameTokenFromPublicKey(byte[] bPublicKeyBlob, int cbPublicKeyBlob, out System.IntPtr ppbStrongNameToken, out int pcbStrongNameToken)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongName.StrongNameTokenFromPublicKey(bPublicKeyBlob, cbPublicKeyBlob, out ppbStrongNameToken, out pcbStrongNameToken);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                ppbStrongNameToken = System.IntPtr.Zero;
                pcbStrongNameToken = 0;
                return false;
            }
            return true;
        }

        [System.Security.SecurityCritical]
        public static bool StrongNameTokenFromPublicKey(System.IntPtr pbPublicKeyBlob, int cbPublicKeyBlob, out System.IntPtr ppbStrongNameToken, out int pcbStrongNameToken)
        {
            int i = Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameUsingIntPtr.StrongNameTokenFromPublicKey(pbPublicKeyBlob, cbPublicKeyBlob, out ppbStrongNameToken, out pcbStrongNameToken);
            if (i < 0)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.ts_LastStrongNameHR = i;
                ppbStrongNameToken = System.IntPtr.Zero;
                pcbStrongNameToken = 0;
                return false;
            }
            return true;
        }

    } // class StrongNameHelpers
}
