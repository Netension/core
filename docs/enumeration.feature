Feature: ESP - Enumeration set base properties

    Scenario: [UNT-ESP001][Success]: Set Id
        When I create a new 'Enumeration' with '1' id
        Then The 'Enumeration.Id' should be '1'

    Scenario: [UNT-ESP001][Success]: Set Name
        When I create a new 'Enumeration' with 'TestName' name
        Then The 'Enumeration.Name' should be 'TestName'

Feature: EEQ - Enumeration equality

    Scenario: [UNT-EEQ001][Success]: Equal Enumeration instances
        Given I have an 'Enumeration' with '1' id
        When I compare it to other 'Enumeration' with 1 id
        Then Two 'Enumeration' instances should be equal

    Scenario Outline: [UNT-EEQ001][Failure]: Unequal Enumeration instances
        Given I have an 'Enumeration' with '1' id
        When I compare it to <instance> instance with <id> id
        Then They should be unequal
        Examples:
            | instance    | id |
            | null        |    |
            | object      |    |
            | Enumeration | 2  |

Feature: EGA - Get all value of Enumeration

    Scenario: [UNT-EGA001]: GetAll Enumeration value
        Given I have an Enumeration type with two static Enumeration value
        When I get all values of the Enumeration
        Then I should get both Enumeration values