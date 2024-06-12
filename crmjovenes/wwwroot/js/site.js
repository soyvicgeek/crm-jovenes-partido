const body = document.querySelector("body")
const sidebar = body.querySelector("nav")
const sidebarToggle = body.querySelector(".sidebar-toggle")

document.addEventListener("DOMContentLoaded", function () {
    const tabla = document.querySelector("#tblDatos")
    tabla.style.width = "100%";
});

sidebarToggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
})