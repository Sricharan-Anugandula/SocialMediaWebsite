using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class EditNew
    {
         public class Command:IRequest
        {
            public Activity Activity{get;set;}
        }

         public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context=context;
                 _mapper = mapper;
            }
          

              async Task  IRequestHandler<Command>.Handle(Command request, CancellationToken cancellationToken)
            {
               Activity act = await _context.Activities.FindAsync(request.Activity.Id);
               
                  _mapper.Map(request.Activity,act);
                await _context.SaveChangesAsync();

            }
        }
    } 
    }
