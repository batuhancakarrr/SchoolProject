document.getElementById("yeni").addEventListener("click", function () {
    document.getElementById("formPopUp").style.display = "flex";
    document.getElementById("overlay").style.display = "block";
});

function closePopup() {
    document.getElementById("formPopUp").style.display = "none";
    document.getElementById("overlay").style.display = "none";
}
