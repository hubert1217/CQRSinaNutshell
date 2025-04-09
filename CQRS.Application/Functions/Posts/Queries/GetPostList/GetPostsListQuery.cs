﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Posts.Queries.GetPostList
{
    public class GetPostsListQuery : IRequest<List<PostInListViewModel>>
    {
    }
}
