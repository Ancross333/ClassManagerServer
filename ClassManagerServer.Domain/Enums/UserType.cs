﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManagerServer.Domain.Enums
{
    public enum UserType
    {
        Student,
        Professor,
        Administrator,
        DemoStudent,
        DemoProfessor,
        DemoAdministrator,
        NotFound,
        Unauthorized
    }
}
