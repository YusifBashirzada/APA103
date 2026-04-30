let calculator = document.getElementById("calculator")

let plus = document.querySelector(".plus")
let minus = document.querySelector(".minus")
let mult = document.querySelector(".mult")
let divide = document.querySelector(".divide")

let inputOne = document.querySelector(".inputOne")
let inputTwo = document.querySelector(".inputTwo")
let total = document.querySelector(".total")

// Her Funksiyanin daxilinde herdefe Numbere cevirmeni uzun yazmamaq ucun deyisen teyin edib GetInputValuede Number Cevirdim
let NumberOne;
let NumberTwo;

// Toplama
let Plus = () => {
    if (GetInputValue() == false) {
        return;
    }

    total.textContent = NumberOne + NumberTwo

    ResetInput()
}

plus.addEventListener("click", Plus)

// Cixma
let Minus = () => {
    if (GetInputValue() == false) {
        return;
    }

    total.textContent = NumberOne - NumberTwo

    ResetInput()
}

minus.addEventListener("click", Minus)

// Vurma
let Mult = () => {
    if (GetInputValue() == false) {
        return;
    }

    total.textContent = NumberOne * NumberTwo

    ResetInput()
}

mult.addEventListener("click", Mult)

// Bolme
let Divide = () => {
    if (GetInputValue() == false) {
        return;
    }
    else if (NumberTwo == 0) {
        alert("0-a Bolme Yoxdur!")
        ResetInput()
        return;
    }

    total.textContent = NumberOne / NumberTwo

    ResetInput()
}

divide.addEventListener("click", Divide)

// Reset Funksiyasi
function ResetInput() {
    inputOne.value = ""
    inputTwo.value = ""
}

// Inputlarin Bos Olub Olmadigini Yoxladigimiz Funksiya
function GetInputValue() {
    if (inputOne.value == "" || inputTwo.value == "") {
        alert("Zəhmət olmasa, hər iki xananı doldurun!")
        ResetInput()
        return false;
    }

    NumberOne = Number(inputOne.value)
    NumberTwo = Number(inputTwo.value)

    if (isNaN(NumberOne) || isNaN(NumberTwo)) {
        alert("Xanalara yalnız rəqəm daxil edilməlidir!")
        ResetInput()
        return false
    }

    return true
}