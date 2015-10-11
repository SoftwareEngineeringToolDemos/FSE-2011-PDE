using System;
using System.Collections.Generic;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions
{
    /// <summary>
    /// This class provides unique keys for identifying V-Modell XT model-elements using
    /// random numbers and GUIDs
    /// 
    /// New: Tranformation of a V-Modell XT ID into a Guid and vice versa
    /// </summary>
    public class KeyGenerator
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static readonly KeyGenerator Instance = new KeyGenerator();

        /// <summary>
        /// Structure used to define the supplement and the identification word 
        /// for the mapping of a VModell XT id (14-16 length) to a GUID
        /// </summary>
        struct IDToGuidMap
        {
            /// <summary>
            /// Identification word, usually the number of needed supplement chars in binary format
            /// </summary>
            public string IDWord;

            /// <summary>
            /// The supplement 
            /// </summary>
            public string IDSupplement;

            /// <summary>
            /// Length of the VModell XT id to which the supplement is applicable
            /// </summary>
            public int VIDLength;

            public IDToGuidMap(string idWord, string idSupplement, int vIDLength)
            {
                IDWord = idWord;
                IDSupplement = idSupplement;
                VIDLength = vIDLength;
            }
        }
        List<IDToGuidMap> idMaps;

        private KeyGenerator()
        {
            idMaps = new List<IDToGuidMap>();
            idMaps.Add(new IDToGuidMap("00011", "00011000000000000000000000000", 3));
            idMaps.Add(new IDToGuidMap("00100", "0010000000000000000000000000", 4));
            idMaps.Add(new IDToGuidMap("00110", "00110000000000000000000000", 6));
            idMaps.Add(new IDToGuidMap("01001", "01001000000000000000000", 9));

            idMaps.Add(new IDToGuidMap("10100", "10100000000000000000", 12));
            idMaps.Add(new IDToGuidMap("10011", "1001100000000000000", 13));
            idMaps.Add(new IDToGuidMap("10010", "100100000000000000", 14));
            idMaps.Add(new IDToGuidMap("10001", "10001000000000000", 15));
            idMaps.Add(new IDToGuidMap("10000", "1000000000000000", 16));

            idMaps.Add(new IDToGuidMap("10101", "101010000000000", 17));
            idMaps.Add(new IDToGuidMap("10111", "10111000000000", 18));
            idMaps.Add(new IDToGuidMap("11000", "1100000000000", 19));
            idMaps.Add(new IDToGuidMap("11001", "110010000000", 20));

        }

        /// <summary>
        /// Create and returns a new unique Key, which is the value for V-Modell XT model-elemenst "id".
        /// </summary>
        /// <returns>A string representig a key/id.</returns>
        public string GenerateKey()
        {
            string guidString = string.Empty;

            /*
             * 1. guidString is first initialzed with a GUID, which is a 128 bit globally unique identifier
             *    (GUID is calculated including network adapter's MAC address, system time and some other stuff)
             */
            guidString = Guid.NewGuid().ToString("N");

            /* 2. GUID-string is cutted to 14 chars length
             *    that will be returned to calling code
             */
            string cuttedGUID = guidString.Substring(0, 14);




            return cuttedGUID;
        }

        /// <summary>
        /// Verifies if a specified vmodell id can be converted to a guid.
        /// </summary>
        /// <param name="vID">Vmodell id</param>
        /// <returns>True if a conversion is possible. False otherwise.</returns>
        public bool CanConvertVModellIDToGuid(string vID)
        {
            if (vID.Length >= 12 && vID.Length <= 16)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Converts a VModell XT ID (14, 15, 16 length) to a GUID by appending
        /// a supplement, which can later be recognized and removed to gain
        /// the VModell XT back
        /// </summary>
        /// <param name="vID">VModell XT ID</param>
        /// <returns>GUID</returns>
        public Guid ConvertVModellIDToGuid(string vID)
        {
            foreach (IDToGuidMap map in idMaps)
                if (vID.Length == map.VIDLength)
                    return new Guid(map.IDSupplement + vID);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts a GUID previously generated through <b>ConvertVModellIDToGuid</b>
        /// back to the V-Modell XT id by removing the supplement.
        /// </summary>
        /// <param name="guid">Guid</param>
        /// <returns>VModell XT ID</returns>
        public string ConvertGuidToVModellID(Guid guid)
        {
            string strGuid = guid.ToString("N");

            foreach (IDToGuidMap map in idMaps)
                if (strGuid.Length > map.IDWord.Length)
                    if (strGuid.Substring(0, map.IDWord.Length) == map.IDWord)
                        return strGuid.Substring(map.IDSupplement.Length, strGuid.Length - map.IDSupplement.Length);

            throw new NotImplementedException("ConvertGuidToVModellID");
        }
    }
}
