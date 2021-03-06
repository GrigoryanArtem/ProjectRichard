﻿using System.Collections.Generic;
using System.Linq;

namespace ProjectRichard.Data
{
    public class NationsManager
    {
        #region Members

        protected List<Nation> mNations = new List<Nation>();

        #endregion

        #region Properites

        public List<Nation> Nations
        {
            get
            {
                return mNations;
            }
        }

        #endregion

        #region Constructors

        private NationsManager()
        {
            Update();
        }

        #endregion

        #region NationsManagerCreated

        sealed private class NationsManagerCreated
        {
            static private readonly NationsManager instance = new NationsManager();

            static public NationsManager Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        static public NationsManager Instance
        {
            get
            {
                return NationsManagerCreated.Instance;
            }
        }

        #endregion

        #region Public methods

        public void Update()
        {
            ProjectRichardDBEntities database = new ProjectRichardDBEntities();

            mNations = database.Nations.ToList();
        }

        public Nation FindByName(string name)
        {
            return mNations
                .Where(nation => nation.Name.ToUpper() == name.ToUpper())
                .FirstOrDefault();
        }

        #endregion
    }
}
