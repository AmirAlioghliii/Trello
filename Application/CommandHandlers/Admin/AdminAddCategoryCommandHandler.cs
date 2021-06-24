using Application.Commands.Admin;
using AutoMapper;
using Infra.Models;
using Infra.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Admin
{
    public class AdminAddCategoryCommandHandler : IRequestHandler<AdminAddCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AdminAddCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AdminAddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _unitOfWork.AdminRepository.AddCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return category.Id;
        }
    }
}
