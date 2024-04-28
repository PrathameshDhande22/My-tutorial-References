def printload(servers: int, processors: int):
    each: int = int(processors/servers)
    extra: int = processors % servers
    total: int = 0
    for i in range(servers):
        if extra > 0:
            total = (each+1)
        else:
            total = each
        extra -= 1
        print("Server", chr(65+i), "Has Processor", total)


servers: int = int(input("Enter the Number of Servers: "))
processors: int = int(input("Enter the Number of Processors: "))

resp = """
Enter 1 to Add Number of Servers
Enter 2 To Remove Number of Servers
Enter 3 to Add Number of Processors
Enter 4 to Remove Number of Servers
Enter 5 To Exit"""

while True:
    printload(servers, processors)
    print("Servers:",servers, "Processors:", processors)
    print(resp)
    choice: int = int(input("Enter the Choice: "))

    if choice == 1:
        servers += int(input("Enter the Number of Server you want to add?:"))
    elif choice == 2:
        servers -= int(input("Enter the Number of Server you want to remove?:"))
    elif choice == 3:
        processors -= int(input("Enter the Number of Processors you want to add?:"))
    elif choice == 4:
        processors -= int(input("Enter the Number of Processors you want to remove?:"))
    elif choice == 5:
        break
    else:
        print("Enter Correct Choice")
