 


namespace Tum.StateMachineDSL.ViewModel
{	
	/// <summary>
	/// This class is used to store common options.
	/// </summary>
	public partial class StateMachineLanguageViewModelOptions : global::Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public StateMachineLanguageViewModelOptions() : base()
		{
		
		}
		
		/*
		/// <summary>
        /// Loads options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        /// <returns>StateMachineLanguageViewModelOptions instance.</returns>
        public static StateMachineLanguageViewModelOptions Deserialize(string filePath)
        {
			System.IO.TextReader r = null;
			try 
			{
    	      	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(StateMachineLanguageViewModelOptions));
    	       	r = new System.IO.StreamReader(filePath);
    	       	StateMachineLanguageViewModelOptions serializableObject = (StateMachineLanguageViewModelOptions)s.Deserialize(r);

    	       	return serializableObject;
			}
			catch
			{
				return new StateMachineLanguageViewModelOptions();
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
        /// <param name="serializableObject">StateMachineLanguageViewModelOptions instance.</param>
        public static void Serialize(string filePath, StateMachineLanguageViewModelOptions serializableObject)
        {
			System.IO.TextWriter w = null;
			try 
			{
            	System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(StateMachineLanguageViewModelOptions));
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
