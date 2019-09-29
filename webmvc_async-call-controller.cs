
using System.Threading.Tasks;

namespace Example.Controllers
{

    public class ExampleController : Controller
    {
    
     /*
     
     Note that the method should have the return type Task<IActionResult> and should be declared async
     */
      public async Task<IActionResult> readAsync()
      {
      
                  // NOTE: the run method should be declared async on the class Get
                  var rows = await (new GetRows()).run();

                  return Json(rows);

      }
    
    }


}
