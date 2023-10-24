// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function search() {
    const searchTerm = document.getElementById('find').value.toUpperCase();
    const storeItems = document.getElementById('Product-List');
    const product = document.querySelectorAll('.card');
    const pname = storeItems.getElementsByTagName('p')
     
    for (var i = 0; i < pname.length; i++) {
        let match = product[i].getElementsByTagName('p')[0];

        if (match) {
            let textValue= match.textContent || match.innerHTML

            if (textValue.toUpperCase().indexOf(searchTerm) > -1) {
                product[i].style.display = "";
            } else {
                product[i].style.display = "none";
            }
        }
    }
}

function RegisterMessage(message) {
    alert("Successfully Registered");
}
