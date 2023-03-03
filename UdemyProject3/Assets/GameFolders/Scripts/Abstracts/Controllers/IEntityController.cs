using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject3.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
    }
}

