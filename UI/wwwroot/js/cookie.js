function setThemeCookie(themeName) {
    document.cookie = `currentTheme=${themeName}`;
    console.log(`cookie set as ${themeName}`);
}

function getTheme() {
    console.log(`cookie returned as ${document.cookie}`);
    return document.cookie;
}