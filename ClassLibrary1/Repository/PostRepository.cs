using Core.Repository;
using SuperCore.Entidade;
using SuperCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCore.Repository
{
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
    }
}
