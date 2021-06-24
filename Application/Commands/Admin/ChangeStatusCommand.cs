﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Admin
{
    public class ChangeStatusCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
