// SPDX-License-Identifier: UNLICENSED
pragma solidity ^0.8.9;

contract MyContract {

    uint256 myNumber;

    constructor() {
        myNumber = 0;
    }

    function setNumber(uint256 _number) public {
        myNumber = _number;
    }


    function getNumber() public view returns (uint256) {
        return myNumber;
    }

    function increment() public {
        myNumber += 1;
    }
}