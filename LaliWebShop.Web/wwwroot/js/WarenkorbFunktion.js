function MachUpdateMengeButtonVisible(id, visible)
{
    const updateMengeButton = document.querySelector("button[data-itemId='" + id + "']");
    if (visible == true) {
        updateMengeButton.style.display = "inline-block";
    }
    else {
        updateMengeButton.style.display = "none";
    }

}