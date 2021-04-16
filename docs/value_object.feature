Feature: VOE- Value object equality

    Scenario: [UNT-VOE001][Success]: Equal by properties
        Given I have an 'ValueObject' with 'TestValue' value
        When I compore it to other 'ValueObject' with 'TestValue' value
        Then Two instances should be equal

    Scenario: [UNT-VOE002][Failure]: Unequal value objects
        Given I have an 'ValueObject' with 'TestValue' value
        When I compore it ot <instance> instance with <value> value
        Then Two instances should be unequal
        Examples:
            | instance | value |
            | null  |   |
            | object  |   |
            | ValueObject  | TestValue2  |