using Entity;
using BL;

var user = new User()
{
    Id = 1,
    Email = "myemail@Gmail.com",
    FirstName = "Алексей",
    LastName = "Непряхин",
    MiddleName = "Сергеевич",
    Active = true,
    Password = "test21"
};

int id = await new UserBL().AddOrUpdateAsync(user);

Console.WriteLine(id);