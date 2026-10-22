using EFCoreTutorial;

Console.WriteLine("EF Core Tutorial");

int tutorialfile = 16;
Runner run;
switch (tutorialfile)
{
    case 1:
        run = new _01_Create();
        await run.RunAsync();
        break;

    case 2:
        run = new _02_Read();
        await run.RunAsync();
        break;

    case 3:
        run = new _03_Update();
        await run.RunAsync();
        break;

    case 4:
        run = new _04_Delete();
        await run.RunAsync();
        break;

    case 5:
        run = new _05_Read_Shadow_Property();
        await run.RunAsync();
        break;

    case 6:
        run = new _06_Create_Record();
        await run.RunAsync();
        break;

    case 7:
        run = new _07_Tracking_No_Tracking_Queries();
        await run.RunAsync();
        break;

    case 8:
        run = new _08_LoadingData();
        await run.RunAsync();
        break;

    case 9:
        run = new _09_LazyLoading();
        await run.RunAsync();
        break;

    case 10:
        run = new _10_ExplicitLoading();
        await run.RunAsync();
        break;

    case 11:
        run = new _11_Split_Query();
        await run.RunAsync();
        break;

    case 12:
        run = new _12_Functions();
        await run.RunAsync();
        break;

    case 13:
        run = new _13_ExecuteDelete();
        await run.RunAsync();
        break;

    case 14:
        run = new _14_ExecuteUpdate();
        await run.RunAsync();
        break;

    case 15:
        run = new _15_Transactions();
        await run.RunAsync();
        break;

    case 16:
        run = new _16_SQL_Query();
        await run.RunAsync();
        break;

    default:
        Console.WriteLine("Nothing Implemented");
        break;
}