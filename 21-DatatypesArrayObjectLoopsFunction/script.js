// Task 1
const arr = [12, 34, 45, 67, 12, 23, 34, 65, 78, 45, 59, 89, 105, 67]

let count = {}
let unique = []

for (let i = 0; i < arr.length; i++) {
    let num = arr[i]

    if (count[num] === undefined) {
        count[num] = 1
        unique.push(num)
    }
    else {
        count[num]++
    }
}

console.log("Unikal:", unique)
console.log("Say:", count)

// Task 2
let word = "Kiçik".toLowerCase()
let isPalindrome = true

for (let i = 0; i < word.length / 2; i++) {
    if (word[i] !== word[word.length - 1 - i]) {
        isPalindrome = false
        break
    }
}

if (isPalindrome) console.log("Soz Palindromdur")
else console.log("Soz Palindrom Deyil")

// Task 3
let a = 20

const array = [15, 23, 45, 65, 78, 2, 90, 32, 3, 5, 8, 22, 49, 63, 82, 103]

let say = 0

for (let i = 0; i < array.length; i++) {
    if (a < array[i]) {
        say++
    }
}

console.log("Say:", say)

// Task 4
let b = 12
let sum = 0

for (let i = 1; i < b; i++) {
    if (b % i == 0) {
        sum += i
    }
}

if (sum > b) console.log("Abundant")
else console.log("Deficient")



// Task 5
const arr2 = [4, 7, 5, 9, 11, 23, 45, 56, 34, 67, 89, 45, 22, 8, 10, 46]

let newarr = []

for (let i = 0; i < arr2.length; i++) {
    let sqrt = arr2[i] ** 2
    newarr.push(sqrt)
}

console.log("Yeni Array:", newarr)