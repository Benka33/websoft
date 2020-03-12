using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
//using webapp.Services;
using webapp.Services;

namespace webap.Controllers
{
    
    public class AccountsController : ControllerBase
    {
        public AccountsController(JsonFileAccountService accountService)
        {
            AccountService = accountService;
        }

        public JsonFileAccountService AccountService { get; }

        [Route("api/accounts")]
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return AccountService.ReadAccounts();
        }
        
        [Route("api/account/{account}")]
        [HttpGet]
        public Account Get(int account)
        {
            IEnumerable<Account> list = AccountService.ReadAccounts();

            Account bankAccount = new Account();
            bankAccount.balance = 0;
            bankAccount.label = "This account does not exist";
            bankAccount.number = -1;
            bankAccount.owner = 0;

            foreach (var acc in list)
            {
                if (acc.number == account)
                {
                    bankAccount = acc;
                    break;
                }
            }

            return bankAccount;
        }

    }
    
    
}