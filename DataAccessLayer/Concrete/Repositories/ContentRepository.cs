﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class ContentRepository : Repository<Content>,IContentDal
    {
        public ContentRepository(Context context) : base(context)
        {
        }
    }
}
