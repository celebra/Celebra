﻿using System;
using System.Collections.Generic;

namespace Celebra.BL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
    }
}
