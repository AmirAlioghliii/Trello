using Application.Commands.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello_.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IMapper _mapper;


        public AdminController(IMapper mapper)
        {
            _mapper = mapper;
        }

        
        //public Task<int> Newtask(AddTaskCommand model)
        //{
        //    _ma
        //}
    }
}
