﻿using Bookcrossing.Application.Commands.Book;
using Bookcrossing.Contracts.Abstractions.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetWithParams(GetBooksWithParametersQuery parametersQuery)
        {
            var result =  _mediator.Send(parametersQuery).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
