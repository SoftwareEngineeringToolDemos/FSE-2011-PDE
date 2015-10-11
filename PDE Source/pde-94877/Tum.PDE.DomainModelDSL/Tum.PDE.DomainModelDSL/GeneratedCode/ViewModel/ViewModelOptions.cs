 


namespace Tum.TestLanguage.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class TestLanguageViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public TestLanguageViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>TestLanguageViewModelOptions instance.</returns>
        public static TestLanguageViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(TestLanguageViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	TestLanguageViewModelOptions serializableObject = (TestLanguageViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new TestLanguageViewModelOptions();
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
        /// <param name="serializableObject">TestLanguageViewModelOptions instance.</param>
        public static void Serialize(string filePath, TestLanguageViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(TestLanguageViewModelOptions));
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
