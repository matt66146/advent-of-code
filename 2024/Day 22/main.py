import time
from termcolor import colored



def mix(secret_num,value):
    return secret_num ^ value

def prune(secret_num):
    return secret_num % 16777216


def step_1(secret_num):
    value = secret_num * 64
    secret_num = mix(secret_num,value)
    secret_num = prune(secret_num)
    return secret_num

def step_2(secret_num):
    value = secret_num // 32
    secret_num = mix(secret_num,value)
    secret_num = prune(secret_num)
    return secret_num

def step_3(secret_num):
    value = secret_num * 2048
    secret_num = mix(secret_num, value)
    secret_num = prune(secret_num)
    return secret_num

def generate_secret(secret_num,num_iterations,nums):
    for i in range(0,num_iterations):
        secret_num = step_1(secret_num)
        secret_num = step_2(secret_num)
        secret_num = step_3(secret_num)
        nums.append(secret_num)
    return secret_num


if __name__ == "__main__":
    def main():
        secret_nums = []
        with open("input.txt") as input_file:
            for line in input_file:
                secret_nums.append(int(line.strip()))


        # part 2
        total = 0

        #secret_nums = [123]

        secret_num_sequences = []
        for secret_num in secret_nums:
            nums = [secret_num]
            num = generate_secret(secret_num, 2000, nums)



            max_nums = []
            for i in range(1,len(nums)):
                #print(nums[i] % 10)
                if i + 3 < len(nums):
                    max_nums.append((nums[i+3] % 10,i+3))
            #print(max_nums)

            sequences = {}
            for num in max_nums:
                sequence = []
                for i in range(num[1]-4,num[1]):
                    if i + 1 < len(nums):
                        #print((nums[i+1] % 10) - (nums[i] % 10))
                        sequence.append((nums[i+1] % 10) - (nums[i] % 10))
                if str(sequence) not in sequences:
                    sequences[str(sequence)] = num[0]


            secret_num_sequences.append({secret_num:sequences})

        dicts =[]
        #print(secret_num_sequences)
        for secret_num_sequence in secret_num_sequences:
            for key in secret_num_sequence:
                dicts.append(secret_num_sequence[key])
        #print(dicts)

        max_dict = {}
        for buyer in dicts:
            for key in buyer:
                if key not in max_dict:
                    max_dict[key] = 0
                max_dict[key] += buyer[key]

        max_sequence = (0,None)
        for key in max_dict:
            if max_dict[key] > max_sequence[0]:
                max_sequence = (max_dict[key],key)
            #print(key,max_dict[key])
        #print(dicts)
        print(max_sequence)



        #part 1
        total = 0
        for secret_num in secret_nums:
            num = generate_secret(secret_num,2000,nums)
            total += num

        print(f'Part 1 - Sum: {total}')






    main()
