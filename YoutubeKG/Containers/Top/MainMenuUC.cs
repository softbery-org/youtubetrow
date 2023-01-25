using Softbery.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeKG.Containers.Top
{
	public partial class MainMenuUC : UserControl, InterfaceContainers
	{
		Logger logger;

		public MainMenuUC()
		{
			InitializeComponent();
			logger = new Logger();

			Logger.Write(logger);
		}

		
	}
}
