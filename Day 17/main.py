import copy





def run_instruction(opcode, operand, machine):
    machine['counter'] += 2
    match opcode:
        case 0:
            combo_operand:int|None = None
            if 0 <= operand <= 3:
                combo_operand = operand
            elif operand == 4:
                combo_operand = machine['a']
            elif operand == 5:
                combo_operand = machine['b']
            elif operand == 6:
                combo_operand = machine['c']

            machine['a'] //= (2 ** combo_operand)

        case 1:
            #XOR
            machine['b'] ^= operand
        case 2:
            combo_operand: int | None = None
            if 0 <= operand <= 3:
                combo_operand = operand
            elif operand == 4:
                combo_operand = machine['a']
            elif operand == 5:
                combo_operand = machine['b']
            elif operand == 6:
                combo_operand = machine['c']

            machine['b'] = combo_operand % 8
        case 3:
            if machine['a'] != 0:
                machine['counter'] = operand
                #print(machine)
        case 4:
            machine['b'] = machine['b'] ^ machine['c']
        case 5:
            combo_operand: int | None = None
            if 0 <= operand <= 3:
                combo_operand = operand
            elif operand == 4:
                combo_operand = machine['a']
            elif operand == 5:
                combo_operand = machine['b']
            elif operand == 6:
                combo_operand = machine['c']
            machine['out'].append(combo_operand % 8)
        case 6:
            combo_operand:int|None = None
            if 0 <= operand <= 3:
                combo_operand = operand
            elif operand == 4:
                combo_operand = machine['a']
            elif operand == 5:
                combo_operand = machine['b']
            elif operand == 6:
                combo_operand = machine['c']

            machine['b'] = machine['a'] // (2 ** combo_operand)
        case 7:
            combo_operand:int|None = None
            if 0 <= operand <= 3:
                combo_operand = operand
            elif operand == 4:
                combo_operand = machine['a']
            elif operand == 5:
                combo_operand = machine['b']
            elif operand == 6:
                combo_operand = machine['c']

            machine['c'] = machine['a'] // (2 ** combo_operand)
        case _:
            print("THIS SHOULDN'T BE POSSIBLE!")

    return machine



def load_machine():
    with open ("input.txt") as file_name:
        machine = {}
        data = file_name.readlines()
        machine['a'] = int(data[0].split(': ')[1].strip())
        machine['b'] = int(data[1].split(': ')[1].strip())
        machine['c'] = int(data[2].split(': ')[1].strip())

        machine['instructions'] = []
        for instruction in data[4].split(': ')[1].split(","):
            machine['instructions'].append(int(instruction))

        machine['counter'] = 0
        machine['out'] = []

    return machine

def run_all_instructions(machine):
    while machine['counter'] < len(machine['instructions']):
        opcode = machine['instructions'][machine['counter']]
        operand = machine['instructions'][machine['counter'] + 1]
        machine = run_instruction(opcode, operand, machine)

    return machine


def find_nums(original_machine,start,current_num):
    for i in range(0, 8):
        machine = copy.deepcopy(original_machine)
        machine['a'] = start + i

        run_all_instructions(machine)

        #print(machine)
        #print(machine['out'])
        #print(machine['instructions'][len(machine['instructions'])-current_num:])

        if machine['out'] == machine['instructions'][len(machine['instructions'])-current_num:]:
            if machine['out'] == machine['instructions']:
                return start + i
            result = find_nums(original_machine,(start + i ) * 8,current_num + 1)
            if result != -1:
                return result
    return -1


if __name__ == '__main__':
    def main():
        original_machine = load_machine()
        start = 0
        current_num = 1


        #part 1
        print(f'Part1: {run_all_instructions(copy.deepcopy(original_machine))["out"]}')
        #part 2
        print(f"Part2: {find_nums(original_machine,start,current_num)}")




    main()


