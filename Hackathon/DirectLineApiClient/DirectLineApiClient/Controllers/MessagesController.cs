using DirectLineApiClient.Models;
using DirectLineApiClient.Services;
using System.Web.Http;

namespace DirectLineApiClient.Controllers
{
    public class MessagesController : ApiController
    {
        ConversationManagerService _conversationManagerService;

        public MessagesController()
        {
            _conversationManagerService = new ConversationManagerService();
        }

        [HttpPost]
        [Route("Start")]
        public IHttpActionResult Start()
        {
            _conversationManagerService.StartNewConversation();
            return Ok();
        }

        [HttpPost]
        [Route("Question")]
        public IHttpActionResult Question(Question question)
        {
            var response = _conversationManagerService.GetMessage(question);
            return Ok(response);
        }
    }
}
