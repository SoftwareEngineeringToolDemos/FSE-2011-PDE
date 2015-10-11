 


namespace Tum.PDE.VSPluginDSL.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class VSPluginDSLViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public VSPluginDSLViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>VSPluginDSLViewModelOptions instance.</returns>
        public static VSPluginDSLViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(VSPluginDSLViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	VSPluginDSLViewModelOptions serializableObject = (VSPluginDSLViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new VSPluginDSLViewModelOptions();
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
        /// <param name="serializableObject">VSPluginDSLViewModelOptions instance.</param>
        public static void Serialize(string filePath, VSPluginDSLViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(VSPluginDSLViewModelOptions));
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
