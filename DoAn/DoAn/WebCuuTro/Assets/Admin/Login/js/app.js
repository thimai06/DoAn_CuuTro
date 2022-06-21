//handle login form
const formLogin = document.querySelector(".login-form");
const formRegister = document.querySelector(".register-form")

const btnCreate = document.querySelector('.btn-create')
const btnRegister = document.querySelector('.btn-register')
const loginBtn = document.querySelector(".login-btn")

btnCreate.addEventListener("click", () => {
    formLogin.classList.remove('open')
    formLogin.classList.add("close")
    formRegister.classList.add("open")
})
btnRegister.addEventListener('click', () => {
    formLogin.classList.add("open")
    formLogin.classList.remove('close')
    formRegister.classList.remove("open")
})
loginBtn.addEventListener('click', () => {
    formLogin.classList.add("open")
    formLogin.classList.remove('close')
    formRegister.classList.remove("open")
})
