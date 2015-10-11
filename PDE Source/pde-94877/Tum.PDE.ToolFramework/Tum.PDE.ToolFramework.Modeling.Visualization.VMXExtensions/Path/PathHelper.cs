using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path
{
    /// <summary>
    /// Helper class for the vmodell path editor.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Calculates the path to the target file relative to the main directory path.
        /// </summary>
        /// <param name="mainDirPath">Main directory path.</param>
        /// <param name="absoluteFilePath">Absolute path to the target file.</param>
        /// <returns>Relative path to the target file.</returns>
        public static string EvaluateRelativePath(string mainDirPath, string absoluteFilePath)
        {
            // examine the two paths and chop off the common part at the start of the paths
            string[] firstPathParts = mainDirPath.Trim(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length, secondPathParts.Length); i++)
            {
                if (!firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            string newPath = String.Empty;

            // different drive, not expected here
            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            // calculate the number of  '../' needed
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += System.IO.Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }

            // append target directories to reach file
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += System.IO.Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }
    }
}
