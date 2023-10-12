//DOM ELEMENTE
const btnMessage = document.getElementById("btn-message");
const userEmail = document.getElementById("email");
const userMessage = document.getElementById("user-message");
const notify = document.getElementById("notify");

//LOGIC
btnMessage.addEventListener("click", (btn) => {

    btn.preventDefault();
    let email = userEmail.value;
    let message = userMessage.value.trim();

    const params = {
        Email: email,
        Text: message
    };

    axios
        .post("api/message/Post", params)
        .catch(error => {
            notify.innerHTML = "Ci dispiace ma abbiamo avuto un problema!"
            notify.classList.add("text-danger");
            notify.classList.remove("text-primary");
            notify.classList.remove("d-none");
        })
        .then(resp => {
            console.log(resp.response);
            userEmail.value = "";
            userMessage.value = "";
            notify.innerHTML = "Messaggio inviato con successo!"
            notify.classList.remove("text-danger");
            notify.classList.add("text-primary");
            notify.classList.remove("d-none");
        }).finally(
            setTimeout(function () {
                notify.classList.add("d-none");
            }, 3000)
        );
});