import time


def gates(input_1, input_2, operator):
    if operator == "AND":
        if input_1 == 1 and input_2 == 1:
            return 1
        else:
            return 0
    elif operator == "OR":
        if input_1 == 1 or input_2 == 1:
            return 1
        else:
            return 0

    elif operator == "XOR":
        if input_1 != input_2:
            return 1
        else:
            return 0

    return -1


def find_equation(in1, in2, operation, equations):
    for equation in equations:
        if in1 in equation and in2 in equation and operation in equation:
            return equation


def adder(wires, equations, x, y, cin):
    if not cin:
        return find_equation(x, y, "AND", equations)[3]

    else:

        try:
            xor1 = find_equation(x, y, "XOR", equations)[3]
            # print(f"{x} XOR {y} = {xor1}")
        except:
            # print(f"{x} XOR {y} = {None}")
            raise Exception

        try:
            sum = find_equation(cin, xor1, "XOR", equations)[3]
            # print(f"{cin} XOR {xor1} = {sum}")
        except:
            # print(f"{cin} XOR {xor1} = {None}")
            raise Exception

        try:
            and1 = find_equation(cin, xor1, "AND", equations)[3]
            # print(f"{cin} AND {xor1} = {and1}")
        except:
            # print(f"{cin} AND {xor1} = {None}")
            raise Exception

        try:
            and2 = find_equation(x, y, "AND", equations)[3]
            # print(f"{x} AND {y} = {and2}")
        except:
            # print(f"{x} AND {y} = {None}")
            raise Exception

        try:
            cout = find_equation(and1, and2, "OR", equations)[3]
            # print(f"{and1} OR {and2} = {cout}")
        except:
            # print(f"{and1} OR {and2} = {None}")
            raise Exception

        print("")
        return cout


def part1():
    wires = {}
    equations = []
    with open("input.txt") as input_file:
        for line in input_file:
            if ":" in line:
                wire = line.strip().split(": ")
                wires[wire[0]] = int(wire[1])
            elif "->" in line:
                equation = line.strip().split(" ")
                equations.append([equation[0], equation[1], equation[2], equation[4]])

    equations_ran = {}
    while len(equations_ran.keys()) < len(equations):
        # print(len(equations_ran.keys()))
        for equation in equations:
            try:
                wires[equation[3]] = gates(wires[equation[0]], wires[equation[2]], equation[1])
                equations_ran[tuple(equation)] = 0
            except Exception as e:
                ""
    wires = dict(sorted(wires.items(), reverse=True))

    return wires, equations


def part2():
    wires = {}
    equations = []
    with open("input_copy.txt") as input_file:
        for line in input_file:
            if ":" in line:
                wire = line.strip().split(": ")
                wires[wire[0]] = int(wire[1])
            elif "->" in line:
                equation = line.strip().split(" ")
                equations.append([equation[0], equation[1], equation[2], equation[4]])

    equations_ran = {}
    while len(equations_ran.keys()) < len(equations):
        # print(len(equations_ran.keys()))
        for equation in equations:
            try:
                wires[equation[3]] = gates(wires[equation[0]], wires[equation[2]], equation[1])
                equations_ran[tuple(equation)] = 0
            except Exception as e:
                ""
    wires = dict(sorted(wires.items(), reverse=True))

    return wires, equations


if __name__ == "__main__":
    def main():
        start = time.time()

        # part 1
        wires, equations = part1()

        total = ""
        z = {}
        for key in wires:
            if key[0] == "z":
                z[key] = wires[key]
                total += str(wires[key])
        x = {}
        x_num = ""
        y_num = ""
        for key in wires:
            if key[0] == "x":
                x[key] = wires[key]
                x_num += str(wires[key])
        y = {}
        for key in wires:
            if key[0] == "y":
                y[key] = wires[key]
                y_num += str(wires[key])

        # part 2
        cin = None
        wires, equations = part2()
        for i in range(0, len(x)):
            cout = adder(wires, equations, f"x{'{:02}'.format(i)}", f"y{'{:02}'.format(i)}", cin)
            cin = cout
        with open("swapped") as input_file:
            nodes = []
            for line in input_file:
                for node in line.strip().split(" - "):
                    nodes.append(node)
        nodes.sort()
        out = str(nodes).replace("[", "").replace("]", "").replace(" ", "").replace("'", "")
        print(f'Part 2: {out}')
        # print(f"Part 2: {int(total, 2)}")

        # part 1
        print(f"Part 1: {int(total, 2)}")
        end = time.time()
        print(f"Total elapsed time: {round(end - start, 2)} seconds")


    main()
