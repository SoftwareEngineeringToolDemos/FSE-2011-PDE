using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    /// <summary>
    /// Source: DSL Tools
    /// </summary>
    public class StrongNameKey : IDisposable
    {
        private const long MaxKeyFileSize = 16384L;

        private string keyFilePath;
        private System.IntPtr newKeyBuffer;
        private int newKeyBufferSize;
        private string publicKey;

        internal string PublicKey
        {
            get
            {
                if (publicKey == null)
                {
                    if (System.String.IsNullOrEmpty(keyFilePath))
                    {
                        byte[] bArr1 = new byte[newKeyBufferSize];
                        System.Runtime.InteropServices.Marshal.Copy(newKeyBuffer, bArr1, 0, newKeyBufferSize);
                        publicKey = StrongNameKey.ExtractPublicKey(null, bArr1);
                    }
                    else
                    {
                        using (System.IO.FileStream fileStream = new System.IO.FileStream(keyFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            byte[] bArr2 = new byte[fileStream.Length];
                            int i = fileStream.Read(bArr2, 0, bArr2.Length);
                            if (i == bArr2.Length)
                                publicKey = StrongNameKey.ExtractPublicKey(keyFilePath, bArr2);
                            else
                                throw new System.IO.EndOfStreamException("reading failed");
                        }
                    }
                }
                return publicKey;
            }
        }

        public StrongNameKey()
        {
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameKeyGen(null, 0, out newKeyBuffer, out newKeyBufferSize) ? 1 : 0);
        }

        public StrongNameKey(string keyFilePath)
        {
            if (System.String.IsNullOrEmpty(keyFilePath))
                throw new System.ArgumentException("Empty file name");
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(keyFilePath);
            if (!fileInfo.Exists)
                throw new System.IO.FileNotFoundException("File doesn't exist", keyFilePath);
            if ((int)fileInfo.Length > 16384)
                throw new System.ArgumentException("File too long");
            this.keyFilePath = keyFilePath;
        }

        private void Dispose(bool disposing)
        {
            if (newKeyBuffer != System.IntPtr.Zero)
            {
                Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameFreeBuffer(newKeyBuffer);
                newKeyBuffer = System.IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public void SaveTo(string destinationFileName)
        {
            if (keyFilePath != null)
            {
                if (System.StringComparer.OrdinalIgnoreCase.Compare(System.IO.Path.GetFullPath(keyFilePath), System.IO.Path.GetFullPath(destinationFileName)) == 0)
                    return;
                System.IO.File.Copy(keyFilePath, destinationFileName, true);
                return;
            }
            if (newKeyBuffer != System.IntPtr.Zero && (newKeyBufferSize > 0))
            {
                byte[] bArr = new byte[newKeyBufferSize];
                System.Runtime.InteropServices.Marshal.Copy(newKeyBuffer, bArr, 0, newKeyBufferSize);
                System.IO.File.WriteAllBytes(destinationFileName, bArr);
                return;
            }
            throw new System.InvalidOperationException();
        }

        ~StrongNameKey()
        {
            Dispose(false);
        }

        private static string ExtractPublicKey(string keyContainer, byte[] keyBlob)
        {
            int i1, i4;
            System.IntPtr intPtr1;

            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameGetPublicKey(keyContainer, keyBlob, keyBlob.Length, out intPtr1, out i1) ? 1 : 0);
            if (i1 != 0)
            {
                byte[] bArr = new byte[i1];
                System.Runtime.InteropServices.Marshal.Copy(intPtr1, bArr, 0, i1);
                Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameFreeBuffer(intPtr1);
                for (int i2 = 0; i2 < bArr.Length; i2++)
                {
                    object[] objArr1 = new object[] { bArr[i2] };
                    stringBuilder.Append(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:X2}\uFFFD", objArr1));
                }
            }
            else
            {
                System.IntPtr intPtr2 = System.IntPtr.Zero;
                int i3 = 0;
                if (Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameTokenFromPublicKey(keyBlob, keyBlob.Length, out intPtr2, out i3))
                {
                    Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameFreeBuffer(intPtr2);
                    if (Microsoft.Runtime.Hosting.StrongNameHelpers.StrongNameSignatureSize(keyBlob, keyBlob.Length, out i4))
                    {
                        for (int i5 = 0; i5 < keyBlob.Length; i5++)
                        {
                            object[] objArr2 = new object[] { keyBlob[i5] };
                            stringBuilder.Append(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:X2}\uFFFD", objArr2));
                        }
                    }
                }
            }
            return stringBuilder.ToString();
        }

        public static bool IsValidKeyFile(string keyFilePath, out string errorMessage)
        {
            bool flag;

            try
            {
                using (StrongNameKey strongNameKey = new StrongNameKey(keyFilePath))
                {
                    if (System.String.IsNullOrEmpty(strongNameKey.PublicKey))
                    {
                        errorMessage = "InvalidKeyFile";
                        flag = false;
                        return flag;
                    }
                    errorMessage = null;
                    flag = true;
                    return flag;
                }
            }
            catch (System.ArgumentException e1)
            {
                errorMessage = e1.Message;
                flag = false;
            }
            catch (System.IO.IOException e2)
            {
                errorMessage = e2.Message;
                flag = false;
            }
            catch (System.UnauthorizedAccessException e3)
            {
                errorMessage = e3.Message;
                flag = false;
            }
            return flag;
        }
    }
}
