using System;


namespace Celebra.BL.Controller
{
    public interface IDataSaver
    {
        void Save(string fileName, object item);
        T Load<T>(string fileName);
    }
}
