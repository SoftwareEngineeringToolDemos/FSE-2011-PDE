 


namespace Tum.VModellXT.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class VModellXTViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public VModellXTViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>VModellXTViewModelOptions instance.</returns>
        public static VModellXTViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(VModellXTViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	VModellXTViewModelOptions serializableObject = (VModellXTViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new VModellXTViewModelOptions();
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
        /// <param name="serializableObject">VModellXTViewModelOptions instance.</param>
        public static void Serialize(string filePath, VModellXTViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(VModellXTViewModelOptions));
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
