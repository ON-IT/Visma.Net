using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Models
{
	public class Attachment
	{
		/*
	 {
            "name": "file.txt",
            "id": "fff491cd-244a-4957-899c-d15f13483a62",
            "revision": 1
        }
		*/		
		public string name { get; set; }
		public Guid id { get; set; }
		public int revision { get; set; }
	}
}
