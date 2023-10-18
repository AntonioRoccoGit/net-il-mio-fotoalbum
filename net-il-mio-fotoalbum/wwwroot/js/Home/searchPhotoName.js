//DOM ELEMENTE
const search = document.getElementById("search-name");
const container = document.getElementById("photo-section");

//VARIABLES
var timeout = null;
let photoArray = [];

search.addEventListener("keyup", () => {
    clearTimeout(timeout);
    timeout = setTimeout(() => {
        photoArray = [];
        let name = search.value;
        axios.get(`api/photo/GetFilterName?name=${name}`).then((response) => {
            photoArray = response.data;
            container.innerHTML = "";
            photoArray.forEach(item => {
                container.innerHTML +=
                    `
                <div class="p-3">

                    <div class="card-photo card col h-100">
                        <img src="${image(item.imageFile)}" style="aspect-ratio:3/2" class="card-img-top" alt="${item.title}">
                        <div class="card-body d-flex flex-column align-items-center">
                            <h5 class="card-title">${item.title}</h5>
                            <section class="flex-grow-1 p-3">
                                <span class="fw-bold">Descrizione:</span>

                                <p class="card-text">${(item.description ?? "Nessuna descrizione")}</p>

                            </section>
                            
                        </div>
                    </div>
                </div>
                `;
            })
        });



    }, 1000);
});

//HELPERS

function image(itemImage) {

    return itemImage ? "data:image/png;base64," + itemImage : "https://www.technol.si/wp-content/uploads/2018/11/default-image1.jpg";
}
