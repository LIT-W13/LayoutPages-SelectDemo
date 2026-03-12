# Steps for creating an MVC project using .Net core

Choose the following template in visual studio:
<img width="2082" height="1348" alt="image" src="https://github.com/user-attachments/assets/211ace2f-6447-495c-8e52-36fa4bfd501a" />

Once the project is created, right click on the project file, and click "Edit Project File":

<img width="1982" height="1538" alt="image" src="https://github.com/user-attachments/assets/2ce203f9-fe9c-4ff5-8757-87dcb5d809bc" />

In there, remove the following line:

```xml
<Nullable>enable</Nullable>
```

and then click save and close that file.

Then, in the HomeController, remove everything except for the following (leave the using statements and the namespace):

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
Then, go into your Views folder, and delete the `Privacy.cshtml` file.

Then, go into the Views/Shared folder and open the _Layout.cshtml file. In there, remove this line from the navbar:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
      </li>
If you want to add your own nav link on top, add something like the following:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-controller="PutYourControllerNameHere" asp-action="PutYourActionNameHere">LinkTextToDisplay</a>
      </li>
Then, at the bottom of the layout, remove the footer:

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2026 - WebApplication17 - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>

## Adding SqlClient into the project from Nuget
`SqlConnection` is no longer in the project by default. We need to get from Nuget. Right click on the project and click "Manage Nuget Packages"
<img width="1894" height="1670" alt="image" src="https://github.com/user-attachments/assets/c7c89035-dd5d-43ec-98e3-08c9cebd6210" />

then, search for "Microsoft.Data.SqlClient" and install it:
<img width="2812" height="1172" alt="image" src="https://github.com/user-attachments/assets/f2002c02-c9c4-4351-a459-7a83aa5b4a56" />


## Adding the connection string
In these new projects, there's no longer a settings file. Therefore, for now we're going to hard code our connection strings at the top of our controllers. 
See here:  https://github.com/LIT-W13/LayoutPages-SelectDemo/blob/master/WebApplication11/Controllers/NorthwindController.cs#L8 (where it says `Northwnd` replace it with the name of your db)

## Dealing with nulls in the database

I showed the following extension method to deal with nulls:

    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string columnName)
        {
            var value = reader[columnName];
            if (value == DBNull.Value)
            {
                return default(T);
            }

            return (T)value;
        }
    }

Code is here:

https://github.com/LIT-W13/LayoutPages-SelectDemo/blob/master/WebApplication11/Extensions.cs

We can then use it like so:
https://github.com/LIT-W13/LayoutPages-SelectDemo/blob/master/WebApplication11/Models/NorthwindDb.cs#L46-L47
