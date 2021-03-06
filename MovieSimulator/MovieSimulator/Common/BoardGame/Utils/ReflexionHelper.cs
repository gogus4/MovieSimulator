﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Utils
{
    public class ReflexionHelper
    {
        private static ReflexionHelper _instance;

        public static ReflexionHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReflexionHelper();

                return _instance;
            }
        }

        public object GetInstance(Assembly a, string simulation, string className, string type)
        {
            try
            {
                Type objectToCreate = a.GetType("MovieSimulator." + simulation + "." + type + "." + className);
                return Activator.CreateInstance(objectToCreate);
            }
            catch (ArgumentNullException) { return null; }
        }
    }
}
