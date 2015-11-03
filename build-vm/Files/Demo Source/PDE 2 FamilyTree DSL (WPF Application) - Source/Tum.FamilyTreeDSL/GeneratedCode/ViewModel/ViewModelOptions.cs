 


namespace Tum.FamilyTreeDSL.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class FamilyTreeDSLViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public FamilyTreeDSLViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>FamilyTreeDSLViewModelOptions instance.</returns>
        public static FamilyTreeDSLViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(FamilyTreeDSLViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	FamilyTreeDSLViewModelOptions serializableObject = (FamilyTreeDSLViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new FamilyTreeDSLViewModelOptions();
			}
			finally
			{
				if( r != null )
					r.Close();
			}
        }
		
		/// <summary>
        /// Save options.
        /// </summary>
        /// <param name="filePath">File name to save options to.</param>
        /// <param name="serializableObject">FamilyTreeDSLViewModelOptions instance.</param>
        public static void Serialize(string filePath, FamilyTreeDSLViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(FamilyTreeDSLViewModelOptions));
            	w = new System.IO.StreamWriter(filePath);
            	s.Serialize(w, serializableObject);
			}
			catch
			{
				// ...
			}
			finally
			{
				if( w != null )
					w.Close();
			}
        }		
		*/
	}
}
