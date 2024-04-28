# ring.py

class Process:
    id: int = 0
    active: bool = True

    def __init__(self, id: int, active: bool) -> None:
        self.id = id
        self.active = active


processes: list[Process] = []

no_of_process: int = int(input("Enter the Number of Process:"))

for i in range(no_of_process):
    processes.append(Process(i, True))

# Asking to fail the Process
fail_process_id: int = int(
    input("Enter the Process ID which You want to Fail: "))

processes[fail_process_id].active = False
print("Process", processes[fail_process_id].id, "Fails")

process_first: int = int(
    input("Enter the Process ID to which Start the Election : "))
process_second: int = int(
    input("Enter the Process ID to Start from the Node: "))


def election_process(process_start: int) -> list[int]:
    process_list: list[int] = []
    curr = process_start
    next = (process_start+1) % no_of_process
    while True:
        if processes[next].active:
            print("Process", processes[curr].id,
                  f"Sends Election({processes[curr].id}) to Process", processes[next].id)
            process_list.append(curr)
            if next == process_start:
                break
            curr = next
        next = (next+1) % no_of_process
    return process_list


def coordinate_process(process_start: int, coordinator: int):
    curr = process_start
    next = (process_start+1) % no_of_process
    while True:
        if processes[next].active:
            print("Process", processes[curr].id,
                  f"Sends Coordinator({processes[coordinator].id}) message to Process", processes[next].id)
            if next == process_start:
                break
            curr = next
        next = (next+1) % no_of_process


process_first_list: list[int] = election_process(process_start=process_first)
process_second_list: list[int] = election_process(process_start=process_second)
if max(process_first_list) == max(process_second_list):
    print("Process", max(process_first_list), "Becomes Coordinator")
coordinate_process(process_first, max(process_second_list))
