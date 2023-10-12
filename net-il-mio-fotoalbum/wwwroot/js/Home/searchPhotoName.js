//DOM ELEMENTE
const search = document.getElementById("search-name");
const container = document.getElementById("photo-section");

//VARIABLES
var timeout = null;
var photoArray = [];

search.addEventListener("keyup", () => {
    clearTimeout(timeout);
    timeout = setTimeout(() => {

        let name = search.value;
        axiosGet(name);
        container.innerHTML = "";

        photoArray.forEach(item => {
            container.innerHTML += `<div class="p-3">

                    <div class="card-photo card col h-100">
                        <img src="https://picsum.photos/seed/picsum/200/300" style="aspect-ratio:3/2" class="card-img-top" alt="${item.Title}">
                        <div class="card-body d-flex flex-column align-items-center">
                            <h5 class="card-title">${item.Title}</h5>
                            <section class="flex-grow-1 p-3">
                                <span class="fw-bold">Descrizione:</span>
                                @if(item.Description?.Count() > 0)
                                {
                                    <p class="card-text">@item.Description</p>
                                }else
                                {
                                    <p class="card-text">Non disponibile</p>
                                }

                            </section>
                            
                        </div>
                    </div>
                </div>`
        })



    }, 1000);
});


function axiosGet(name) {
    axios
        .get("api/photo/GetFilterName?name=" + name)
        .then(resp => photoArray = resp);
}