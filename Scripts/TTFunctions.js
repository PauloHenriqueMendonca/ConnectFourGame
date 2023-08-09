const playerRed = "R";
const playerYellow = "Y";
var currentPlayer = playerRed;
var quantMoves = 0;
var gameOver = false;
var board;
var currColumns;
var winner;
var rows = 6;
var columns = 7;

$(document).on("click", "#restartGame", setGame);
$(document).on("click", ".deleteGame", DeleteGame);
window.onload = function (e) {
    if (e.target.location.pathname == "/Home/Game")
    setGame();
}

function togglePlayer() {
    if (currentPlayer == playerRed) {
        $('#Player').addClass("red-piece");
        $('#Player').removeClass("yellow-piece");
    } else {
        $('#Player').removeClass("red-piece");
        $('#Player').addClass("yellow-piece");
    }
}

function setGame() {
    // board will correspond to the tiles in the html page
    board = [];
    currColumns = Array(rows).fill(rows - 1);
    currentPlayer = playerRed;
    quantMoves = 0;
    gameOver = false;

    $('#PlayerBox').show();
    $('#board').empty();
    $('#winner').empty();

    togglePlayer();

    for (let r = 0; r < rows; r++) {
        let row = [];
        for (let c = 0; c < columns; c++) {
            row.push('');

            //creates a div tag and set the id to the index position where it first starts at [0,0]
            //then add a style class of tile and take the tag and append it 
            let tile = document.createElement("div");
            tile.id = r.toString() + "-" + c.toString();
            tile.classList.add("tile");
            //add an event to the click calling the function setPiece
            tile.addEventListener("click", setPiece);
            //this line of code appends the tiles in the html div automatic
            document.getElementById("board").append(tile);
        }
        board.push(row);
    }
}

function setPiece() {
    //first have to check if the game is over, cause if it is cant allow player to add other pieces
    if (gameOver) {
        return;
    }
    //if game is not over than we have to get the coordinates of the event click
    let coords = this.id.split("-");
    //the coords will come as a string so have to convert it to int 
    let r = parseInt(coords[0]);
    let c = parseInt(coords[1]);
    quantMoves++;

    //created another array of currColumns to keep track of the positions so they fall to the bottom 
    r = currColumns[c]; // so it will get the height for that specif column
    if (r < 0) {//means that the column if filled
        return;
    }

    //update the board
    board[r][c] = currentPlayer;
    let tile = document.getElementById(r.toString() + "-"+ c.toString());

    if (currentPlayer == playerRed) {
        tile.classList.add("red-piece");
        currentPlayer = playerYellow;
    }
    else {
        tile.classList.add("yellow-piece");
        currentPlayer = playerRed;
    }

    togglePlayer();

    //update r so it subtracts 1 to move up one row os it updates the height of the column
    r -= 1;
    currColumns[c] = r; // update the array

    checkWinner();
}


function checkWinner() {
    //to check for the winners will have to loop the indexes [0,0][0,1]..etc
    //Horizontal check for winner will loop through the row piece by piece
    for (let r = 0; r < rows; r++) {
        for (let c = 0; c < columns-3; c++) {
            if (board[r][c] != '') {
                if (board[r][c] == board[r][c + 1] && board[r][c + 1] == board[r][c + 2] && board[r][c + 2] == board[r][c + 3]) {
                    setWinner(r, c);
                    return;
                }
            }
        }
    }
    //verticaly check for the winner
    for (var c = 0; c < columns; c++) {
        for (var r = 0; r < rows-3; r++) {
            if (board[r][c] != '') {
                if (board[r][c] == board[r + 1][c] && board[r + 1][c] == board[r + 2][c] && board[r+2][c] == board[r+3][c]) {
                    setWinner(r, c);
                    return;
                }
            }
        }
    }
    //antidiagonal check for the winner
    for (var r = 0; r < rows - 3; r++) {
        for (var c = 0; c < columns-3; c++) {
            if (board[r][c] != '') {
                if (board[r][c] == board[r + 1][c + 1] && board[r + 1][c + 1] == board[r + 2][c + 2] && board[r + 2][c + 2] == board[r + 3][c + 3]) {
                    setWinner(r, c);
                    return;
                }
            }
        }
    }
    // diagonal check for winner
    for (var r = 3; r < rows; r++) {
        for (var c = 0; c < columns-3; c++) {
            if (board[r][c] != '') {
                if (board[r][c] == board[r - 1][c + 1] && board[r - 1][c + 1] == board[r - 2][c + 2] && board[r - 2][c + 2] == board[r - 3][c + 3]) {
                    setWinner(r, c);
                    return;
                }
            }
        }
    }

}

function setWinner(r, c) {
    $('#PlayerBox').hide();
    winner = document.getElementById("winner");

    if (board[r][c] == playerRed) {
        winner.innerText = "Red wins!";
    }
    else {
        winner.innerText = "Yellow Wins!";
    }

    gameOver = true;
    saveGame();
}

function saveGame() {
    //make the model
    var model = new Object();
    model.Date = new Date();
    model.UserId = game.userID;
    model.Winner = winner.innerText;
    model.QuantMoves = quantMoves;

    //ajax call
    $.ajax({
        type: 'POST',
        url: window.location.origin + "/Home/SaveGame",
        data: JSON.stringify(model),
        //tratar o caminho de sucesso
        success: function (data) {
            if (data.Error) {
                alert(data.ErrorMessage);
            } else {
                $('#savedGame').show();
            }
        },
        dataType: 'json',
        contentType: "application/json; charset=utf",
    });
}

function restartGame() {
    $('#board').empty();
    $('#winner').empty();
    currentPlayer = playerRed;
    quantMoves = 0;
    gameOver = false;

    setGame();
}

function DeleteGame(e) {

    var gameID = $(e.target).closest('button').data('gameid');
    //ajax call
    $.ajax({
        type: 'POST',
        url: window.location.origin + "/Home/DeleteGame",
        data: {
            gameID: gameID,
        },
        //tratar o caminho de sucesso
        success: function (data) {
            if (data.Error) {
                alert(data.ErrorMessage);
            } else {
                window.location.reload();
            }
        },
    });
}