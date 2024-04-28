class Process:
    id: int = 0
    active: bool = True

    def __init__(self, id: int, active: bool):
        self.id = id
        self.active = active


processes: list[Process] = []


def getMaxID() -> int:
    maxID: int = -99
    index: int = -1
    for i in processes:
        if i.active and i.id >= maxID:
            maxID = i.id
            index = processes.index(i)
    return index


no_of_process: int = int(input("Enter the number of processes: "))
for i in range(no_of_process):
    processes.append(Process(i, True))
print("Process", processes[getMaxID()].id, "Fails")
processes[getMaxID()].active = False

election_initiator: int = int(input("Enter the Election Initiator Process : "))
print("Election Initiated by Process", election_initiator)

election_start: bool = True
while election_start:

    if not processes[election_initiator+1].active:
        election_start = False
        break

    # Starting the election process
    for i in range(election_initiator+1, no_of_process):
        if processes[i].active:
            print("Process", election_initiator,
                  f"passes Election({election_initiator}) to Process", processes[i].id)

    # Sending the OK messages
    for i in range(no_of_process-1, election_initiator, -1):
        if processes[i].active:
            print(
                "Process", processes[i].id, f"Passes OK({processes[i].id}) to Process", processes[election_initiator].id)

    election_initiator += 1
print("Finally Process",
      processes[election_initiator].id, "becomes Coordinator")

# Sending the Coordinator Messages
for i in reversed(processes):
    if i.active and election_initiator != i.id:
        print("Process", processes[election_initiator].id,
              f"Sends Coordinate({processes[election_initiator].id}) Message to Process", i.id)
print("End of Election")
