using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        // dependency injection
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public int HeadingCount()
        {
            throw new NotImplementedException();
        }
    }
}
