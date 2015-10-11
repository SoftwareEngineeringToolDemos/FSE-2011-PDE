 


namespace Tum.PDE.ModelingDSL.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class PDEModelingDSLViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public PDEModelingDSLViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>PDEModelingDSLViewModelOptions instance.</returns>
        public static PDEModelingDSLViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(PDEModelingDSLViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	PDEModelingDSLViewModelOptions serializableObject = (PDEModelingDSLViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new PDEModelingDSLViewModelOptions();
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
        /// <param name="serializableObject">PDEModelingDSLViewModelOptions instance.</param>
        public static void Serialize(string filePath, PDEModelingDSLViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(PDEModelingDSLViewModelOptions));
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
